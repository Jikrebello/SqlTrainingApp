namespace SqlTrainingApp
{
    public class Customer
    {
        private int myID;
        private string myName;

        public Customer(int _id, string _Name)
        {

            myID = _id;
            myName = _Name;
        }
        public int ID
        {

            get
            {
                return myID;
            }
        }

        public string Name
        {
            get
            {
                return myName;
            }
        }

    }
}
