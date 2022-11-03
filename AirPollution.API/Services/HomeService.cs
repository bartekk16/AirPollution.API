namespace AirPollution.API.Services
{
    public class HomeService : IHomeService
    {
        //private int a = 5;

        public HomeService()
        {
            //this.a = a;
        }

        public int GetInt()
        {
            return 6;
        }

        public int PostInt(int x)
        {
            return x;
        }
    }
}
