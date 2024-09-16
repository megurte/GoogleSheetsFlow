using System.Collections.Generic;
using Google.Apis.Sheets.v4.Data;
using GoogleSheetsFlow.SheetBuilder.Interfaces;

namespace GoogleSheetsFlow.SheetBuilder.Reading
{
    public interface IRangeOperations
    {
        GoogleSheetsCommandBuilder AddRange(int sheetId, int startRowIndex, int endRowIndex, int startColumnIndex, 
            int endColumnIndex, BooleanCondition condition,
            CellFormat format);
    }
    
    public class RangeOperations : IRangeOperations
    {
        private readonly List<Request> _requests;
        private readonly GoogleSheetsCommandBuilder _builder;

        public RangeOperations(List<Request> requests, GoogleSheetsCommandBuilder builder)
        {
            _requests = requests;
            _builder = builder;
        }
        
                
        public GridRange CreateGridRange(int sheetId, int startRowIndex, int endRowIndex, int startColumnIndex, int endColumnIndex)
        {
            return new GridRange
            {
                SheetId = sheetId,
                StartColumnIndex = startColumnIndex,
                EndColumnIndex = endColumnIndex,       
                StartRowIndex = startRowIndex,
                EndRowIndex = endRowIndex,
            };
        }
        
        public BooleanCondition CreateBooleanCondition(string conditionType, string value)
        {
            return new BooleanCondition
            {
                Type = conditionType,
                Values = new List<ConditionValue>
                {
                    new ConditionValue { UserEnteredValue = value }
                }
            };
        }
        
        public Request CreateConditionalFormatRequest(ConditionalFormatRule rule)
        {
            return new Request
            {
                AddConditionalFormatRule = new AddConditionalFormatRuleRequest
                {
                    Rule = rule
                }
            };
        }
        
        public ConditionalFormatRule CreateConditionalFormatRule(GridRange range, BooleanCondition condition, CellFormat format)
        {
            return new ConditionalFormatRule
            {
                BooleanRule = new BooleanRule
                {
                    Condition = condition,
                    Format = format
                },
                Ranges = new List<GridRange> { range }
            };
        }
        
        public CellFormat CreateCellFormat(float red, float green, float blue)
        {
            return new CellFormat
            {
                NumberFormat = new NumberFormat()
                {
                    Pattern = "##0.00%"
                },
                BackgroundColor = new Color { Red = red, Green = green, Blue = blue }
            };
        }

        public GoogleSheetsCommandBuilder AddRange(int sheetId, int startRowIndex, int endRowIndex, int startColumnIndex, int endColumnIndex, BooleanCondition condition,
            CellFormat format)
        {
            var range = CreateGridRange(sheetId, startRowIndex, endRowIndex, startColumnIndex, endColumnIndex);
            var rule = CreateConditionalFormatRule(range, condition, format);
            var request = CreateConditionalFormatRequest(rule);
            
            _requests.Add(request);
            return _builder;
        }
    }
}