using Google.Apis.Sheets.v4;
using GoogleSheetsFlow.SheetBuilder;

namespace GoogleSheetsFlow
{
    public class TestClass
    {
        public void Main()
        {

            var service = new SheetsService();
            var spreadsheetId = "";
            var sheetsBuilder = new GoogleSheetsCommandBuilder(service, spreadsheetId);

            sheetsBuilder
                .AddSheet("NewSheet") 
                .AddRange(1, 1, 1000) 
                .AddRange(1, 1001, 2000)
                .ExecuteBatch(); 
        }
    }
}