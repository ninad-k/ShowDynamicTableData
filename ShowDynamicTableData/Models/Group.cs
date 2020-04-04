using System.Collections.Generic;

namespace ShowDynamicData.Models
{
    public class Group
    {
        public string Header { get; set; }
        public IList<IGroupRow> Rows { get; } = new List<IGroupRow>();
    }
}