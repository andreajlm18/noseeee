using UnitAppLibrary;
namespace Unit.AppProgram
{

    public class UnitAppProgram
    {
        public static void Main()
        {
            var unitApp = new UnitAppLogic();
            unitApp.ReadJSON("Example.json");
        }
    }
}