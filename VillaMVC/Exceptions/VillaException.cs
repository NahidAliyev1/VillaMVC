namespace VillaMVC.Exceptions;

public class VillaException:Exception
{
    public VillaException():base("Default mesajdir")
    {
        
    }
    public VillaException(string errormessage):base(errormessage)
    {
        
    }

}
