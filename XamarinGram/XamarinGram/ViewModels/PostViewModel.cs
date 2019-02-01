using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinGram.ViewModels
{
    public class PostViewModel : WordPressPCL.Models.Post
    {
        public MediaViewModel Media { get; set; }
    }
}
