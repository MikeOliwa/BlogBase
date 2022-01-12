using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogBase.Models {
    public class BlogPost {

        public int Id { get; set; }

        // filled in by user
        public string Title { get; set; }

        public string Text { get; set; }

        public string PreviewText { get; set; }

        public byte[] Picture { get; set; }
        // until here

        public DateTime DateCreated { get; set; }

        public DateTime DateEdited { get; set; }

        public string Author { get; set; }



    }
}
