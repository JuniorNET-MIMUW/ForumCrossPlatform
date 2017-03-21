using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.ViewModels
{
    class ThreadViewModel
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public string Message { get; set; }

        public IList<CommentViewModel> Comments { get; set; }
    }
}
