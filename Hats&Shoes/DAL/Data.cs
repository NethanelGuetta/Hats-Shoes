namespace Hats_Shoes.DAL
{
    public class Data
    {
        private readonly string connectionString = "server=LAPTOP-9ENQOSOT\\SA;initial catalog=Brand_store;user id=SA;password=1234;TrustServerCertificate=Yes";

        private static Data _data;
        private DataLayer DataLayer;
        private Data()
        {
            DataLayer = new DataLayer(connectionString);
        }
        public static DataLayer Get
        {
            get
            {
                if (_data == null)
                    _data = new Data();
                return _data.DataLayer;
            }
        }
    }
}
