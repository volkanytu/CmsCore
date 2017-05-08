using System;
using System.Collections.Generic;
using System.Linq;

namespace CmsCore.Library.Entities
{
    public class ResultTable
    {
        public int TotalCount { get; set; }
        public List<ResultColumn> Columns { get; set; } = new List<ResultColumn>();
        public List<ResultRow> Rows { get; set; } = new List<ResultRow>();
        public ResultColumn[] PrimaryKey { get; set; }
        public ResultRow NewRow()
        {
            return new ResultRow(Columns, new object[Columns.Count]);
        }
    }
    public class ResultColumn
    {
        public string ColumnName { get; set; }
        public Type ColumnType { get; set; }
    }

    public class ResultRow
    {
        private readonly object[] _itemArray;
        public List<ResultColumn> Columns { get; }
        public ResultRow(List<ResultColumn> columns, object[] itemArray)
        {
            Columns = columns;
            _itemArray = itemArray;
        }
        public object this[int index]
        {
            get => _itemArray[index];
            set => _itemArray[index] = value;
        }
        public object this[string columnName]
        {
            get
            {
                var i = Columns.TakeWhile(column => column.ColumnName != columnName).Count();
                return _itemArray[i];
            }
            set
            {
                var i = Columns.TakeWhile(column => column.ColumnName != columnName).Count();
                _itemArray[i] = value;
            }
        }
    }
}