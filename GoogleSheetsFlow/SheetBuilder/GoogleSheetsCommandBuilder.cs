using System;
using System.Collections.Generic;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using GoogleSheetsFlow.SheetBuilder.Interfaces;
using GoogleSheetsFlow.SheetBuilder.Reading;
using GoogleSheetsFlow.SheetBuilder.SheetCommands;

namespace GoogleSheetsFlow.SheetBuilder
{
    public class GoogleSheetsCommandBuilder : IGoogleSheetsContext
    {
        private readonly SheetsService _service;
        private readonly string _spreadsheetId;
        private readonly List<Request> _requests = new List<Request>();
        
        private readonly SheetOperations _sheetOperations;
        private readonly RangeOperations _rangeOperations;

        public GoogleSheetsCommandBuilder(SheetsService service, string spreadsheetId)
        {
            _service = service;
            _spreadsheetId = spreadsheetId;
            
            _sheetOperations = new SheetOperations(_requests, this);
            _rangeOperations = new RangeOperations(_requests, this);
        }
        
        public IGoogleSheetsContext AddSheet(string sheetTitle)
        {
            return _sheetOperations.AddSheet(sheetTitle); 
        }

        public IGoogleSheetsContext AddRange(int sheetId, int startRowIndex, int endRowIndex)
        {
            return _rangeOperations.AddRange(sheetId, startRowIndex, endRowIndex); 
        }
        
        public void ExecuteBatch()
        {
            if (_requests.Count > 0)
            {
                var batchRequest = new BatchUpdateSpreadsheetRequest
                {
                    Requests = _requests
                };

                _service.Spreadsheets.BatchUpdate(batchRequest, _spreadsheetId).Execute();
            }
            else
            {
                Console.WriteLine("No requests to execute.");
            }
        }
    }
}