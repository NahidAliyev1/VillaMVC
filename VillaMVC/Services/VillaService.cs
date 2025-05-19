using Microsoft.EntityFrameworkCore;
using VillaMVC.Contexts;
using VillaMVC.Exceptions;
using VillaMVC.Models;
using VillaMVC.ViewModels;

namespace VillaMVC.Services;

public class VillaService
{

    private readonly AppDbContext _context;
    public VillaService(AppDbContext appDbContext )
    {
        _context = appDbContext;
    }
    #region Read
    public List<Villa> GetAllVilla()
    {
        List<Villa> villas = _context.Villa.ToList();
        return villas;
    }
    public Villa GetVillaById(int id)
    {
        Villa? villa = _context.Villa.Find(id);

        if (villa is null)
        {
            throw new VillaException($"Databada {id} idsi tapilmadi");
        }
        return villa;
    }
    #endregion
    #region Create
    public void CreateVilla(VillaVM villaVM)
    {
        Villa newVilla = new Villa();
        newVilla.CategoryName = villaVM.CategoryName;
        newVilla.Price = villaVM.Price;
        newVilla.Place = villaVM.Place;
        newVilla.Bedrooms = villaVM.Bedrooms;
        newVilla.Bathrooms = villaVM.Bathrooms;
        newVilla.Area = villaVM.Area;
        newVilla.Floor = villaVM.Floor;
        newVilla.Parking = villaVM.Parking;


        string filename = Path.GetFileNameWithoutExtension(villaVM.ImgFile.FileName);
        string extension = Path.GetExtension(villaVM.ImgFile.FileName);
        string resultname = filename + Guid.NewGuid().ToString() + extension;

        string uploadPath = "C:\\Users\\II Novbe\\source\\repos\\VillaMVC\\VillaMVC\\wwwroot\\assets\\uploadedImages";
        uploadPath = Path.Combine(uploadPath,resultname);

        using FileStream stream = new FileStream(uploadPath,FileMode.Create);
        villaVM.ImgFile.CopyTo(stream);
        newVilla.ImgPath = resultname;


        _context.Villa.Add(newVilla);
        _context.SaveChanges();
    }
    #endregion

    #region Update

    public void UpdateVilla(int id,VillaVM villaVM) 
    {
        Villa? villa1 = _context.Villa.AsNoTracking().SingleOrDefault(vl => vl.Id == id);

        if (villa1 is null)
        {
            throw new VillaException($"Databasada {id} sahib bir id tapilmadi");
        }

        villa1.CategoryName = villaVM.CategoryName;
        villa1.Price = villaVM.Price;
        villa1.Place = villaVM.Place;
        villa1.Bedrooms = villaVM.Bedrooms;
        villa1.Bathrooms = villaVM.Bathrooms;
        villa1.Area = villaVM.Area;
        villa1.Floor = villaVM.Floor;
        villa1.Parking = villaVM.Parking;


        if (villaVM.ImgFile is not null)
        {
            string filename = Path.GetFileNameWithoutExtension(villaVM.ImgFile.FileName);
            string extension = Path.GetExtension(villaVM.ImgFile.FileName);
            string resultname = filename + Guid.NewGuid().ToString() + extension;

            string uploadPath = "C:\\Users\\II Novbe\\source\\repos\\VillaMVC\\VillaMVC\\wwwroot\\assets\\uploadedImages";
            uploadPath = Path.Combine(uploadPath, resultname);

            using FileStream stream = new FileStream(uploadPath, FileMode.Create);
            villaVM.ImgFile.CopyTo(stream);
            villa1.ImgPath = resultname;
        }




       
      
            _context.Villa.Update(villa1);
            _context.SaveChanges();
        
    }
    #endregion

    #region Delete
    public void DeleteVilla(int id) 
    {
        Villa? villa = _context.Villa.Find(id);

        if (villa is null)
        {
            throw new VillaException($"databasada {id} buna sahib bir id tapilimadi");
        }

        _context.Remove(villa);
        _context.SaveChanges();

    }
    #endregion

}
