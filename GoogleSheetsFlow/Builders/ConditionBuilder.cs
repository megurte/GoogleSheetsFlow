using System.Collections.Generic;
using Google.Apis.Sheets.v4.Data;

namespace GoogleSheetsFlow.SheetBuilder
{
    public class ConditionBuilder
    {
        private string _conditionType;
        private string _value;

        public ConditionBuilder WithCondition(string conditionType, string value)
        {
            _conditionType = conditionType;
            _value = value;
            return this;
        }

        public BooleanCondition Build()
        {
            return new BooleanCondition
            {
                Type = _conditionType,
                Values = new List<ConditionValue>
                {
                    new ConditionValue { UserEnteredValue = _value }
                }
            };
        }
    }
}