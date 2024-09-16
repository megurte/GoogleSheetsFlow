using Google.Apis.Sheets.v4.Data;
using GoogleSheetsFlow.SheetBuilder.Reading;

namespace GoogleSheetsFlow.SheetBuilder.Interfaces
{
    public interface IGoogleSheetsContext
    {
        IGoogleSheetsContext AddSheet(string sheetTitle);

        IGoogleSheetsContext AddRange(int sheetId, int startRowIndex, int endRowIndex, int startColumnIndex, 
            int endColumnIndex, BooleanCondition condition, CellFormat format);

        void ExecuteBatch();
    }
}