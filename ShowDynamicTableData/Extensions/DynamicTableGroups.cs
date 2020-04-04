using ShowDynamicData.Models;
using ShowDynamicData.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ShowDynamicTableData.Extensions
{
    public static class DynamicTableGroups
    {
        public static readonly BindableProperty GroupsProperty =
            BindableProperty.CreateAttached("GroupsProperty",
              typeof(IList<Group>),
              typeof(DynamicTableGroups),
              null, BindingMode.OneWay, propertyChanged: GroupsChanged);

        private static void GroupsChanged(BindableObject source, object oldVal, object newVal)
        {
            // when groups change we need to rebuild our TableView content

            var tableView = (TableView)source;
            var newGroups = (IList<Group>)newVal;

            tableView.Root.Clear();

            if (newGroups == null)
            {
                return;
            }

            foreach (var group in newGroups)
            {
                tableView.Root.Add(GroupsFactory.CreateSection(group));
            }
        }
    }
}
