using System.Collections.Generic;
using Google.Apis.Sheets.v4.Data;
using GoogleSheetsFlow.SheetBuilder.Reading;

namespace GoogleSheetsFlow.SheetBuilder.SheetCommands
{
    public interface ISheetOperations
    {
        GoogleSheetsCommandBuilder AddSheet(string sheetTitle);
        RangeOperations Ranges { get; }
    }
    
    public class SheetOperations : ISheetOperations
    {
        private readonly List<Request> _requests;
        private readonly GoogleSheetsCommandBuilder _builder;

        public SheetOperations(List<Request> requests, GoogleSheetsCommandBuilder builder)
        {
            _requests = requests;
            _builder = builder;
        }

        public GoogleSheetsCommandBuilder AddSheet(string sheetTitle)
        {
            var addSheetRequest = new Request
            {
                AddSheet = new AddSheetRequest
                {
                    Properties = new SheetProperties
                    {
                        Title = sheetTitle
                    }
                }
            };

            _requests.Add(addSheetRequest);
            return _builder;
        }

        public RangeOperations Ranges => new RangeOperations(_requests, _builder);
    }
}