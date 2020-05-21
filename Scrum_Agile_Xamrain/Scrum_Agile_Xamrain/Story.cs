using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scrum_Agile_Xamrain
{
    public class Story
    {
        [PrimaryKey, AutoIncrement]
        public int StoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectName { get; set; }
        public string PersonName { get; set; }
    }
}
