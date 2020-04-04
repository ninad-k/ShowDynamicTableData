using System;

namespace ShowDynamicData.Models
{
    public class ButtonRow : IGroupRow
    {
        public string Title { get; set; }
        public Action OnClickAction { get; set; }
    }
}