using Google.Apis.Sheets.v4.Data;

namespace GoogleSheetsFlow.SheetBuilder
{
    public class FormatBuilder
    {
        private float _red;
        private float _green;
        private float _blue;

        public FormatBuilder WithBackgroundColor(float red, float green, float blue)
        {
            _red = red;
            _green = green;
            _blue = blue;
            return this;
        }

        public CellFormat Build()
        {
            return new CellFormat
            {
                BackgroundColor = new Color { Red = _red, Green = _green, Blue = _blue }
            };
        }
    }
}