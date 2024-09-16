using System.Collections.Generic;
using Google.Apis.Sheets.v4.Data;
using GoogleSheetsFlow.SheetBuilder.Interfaces;

namespace GoogleSheetsFlow.SheetBuilder.Reading
{
    public class RangeOperations : IRangeOperations
    {
        private readonly List<Request> _requests;
        private readonly GoogleSheetsCommandBuilder _builder;

        public RangeOperations(List<Request> requests, GoogleSheetsCommandBuilder builder)
        {
            _requests = requests;
            _builder = builder;
        }

        public GoogleSheetsCommandBuilder AddRange(int sheetId, int startRowIndex, int endRowIndex)
        {
            var range = new GridRange
            {
                SheetId = sheetId,
                StartColumnIndex = 0,
                StartRowIndex = startRowIndex,
                EndRowIndex = endRowIndex
            };

            var request = new Request
            {
                AddConditionalFormatRule = new AddConditionalFormatRuleRequest
                {
                    Rule = new ConditionalFormatRule
                    {
                        Ranges = new List<GridRange> { range }
                    }
                }
            };

            _requests.Add(request);
            return _builder;
        }
    }
}