using System.Collections.ObjectModel;

namespace TOFont.ViewModel
{
    public class CharsModel
    {
        public ObservableCollection<Charu> CharItems;

        public CharsModel()
        {
            CharItems = new ObservableCollection<Charu>();
            for (int i = 48; i < 90; i++)
            {
                CharItems.Add(new Charu()
                {
                    Char = ((char)i).ToString()
                });
            }
        }
    }

    public class Charu
    {

        private string _Char;
        public string Char
        {
            get { return this._Char; }
            set { this._Char = value; }
        }
    }
}
