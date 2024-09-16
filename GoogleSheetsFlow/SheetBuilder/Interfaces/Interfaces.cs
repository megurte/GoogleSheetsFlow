using GoogleSheetsFlow.SheetBuilder.Reading;

namespace GoogleSheetsFlow.SheetBuilder.Interfaces
{
    public interface IGoogleSheetsContext
    {
        IGoogleSheetsContext AddSheet(string sheetTitle);

        IGoogleSheetsContext AddRange(int sheetId, int startRowIndex, int endRowIndex);

        void ExecuteBatch();
    }
    
    public interface ISheetOperations
    {
        GoogleSheetsCommandBuilder AddSheet(string sheetTitle);
        RangeOperations Ranges { get; }
    }

    public interface IRangeOperations
    {
        GoogleSheetsCommandBuilder AddRange(int sheetId, int startRowIndex, int endRowIndex);
    }
}