using System.Collections.Generic;

namespace TaskManager.Web.Common
{
    public class Priority
    {
        public int PriorityId { get; set; }
        public string NamePriority { get; set; }

        public static IEnumerable<Priority> ReturnPrioritiesForViewModel()
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

            return priorities;
        }
    }
}
