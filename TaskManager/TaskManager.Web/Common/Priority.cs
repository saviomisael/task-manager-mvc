using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TaskManager.Web.Common
{
    public class Priority
    {
        public int PriorityId { get; private set; }
        public string NamePriority { get; private set; }

        public static SelectList ReturnPrioritiesForSelectList()
        {
            var priorities = new List<Priority>();

            priorities.Add(new Priority()
            {
                PriorityId = 1,
                NamePriority = "Pequena"
            });

            priorities.Add(new Priority()
            {
                PriorityId = 2,
                NamePriority = "Média"
            });

            priorities.Add(new Priority()
            {
                PriorityId = 3,
                NamePriority = "Grande"
            });

            return new SelectList(priorities, "PriorityId", "NamePriority");
        }
    }
}
