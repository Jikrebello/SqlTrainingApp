namespace SqlTrainingApp
{
    public class Parts
    {
        private int myID;
        private string myPart;

        public Parts(int _id, string _Part)
        {

            myID = _id;
            myPart = _Part;
        }

        public int ID
        {

            get
            {
                return myID;
            }
        }

        public string PartDescription
        {
            get
            {
                return myPart;
            }
        }

    }
}
