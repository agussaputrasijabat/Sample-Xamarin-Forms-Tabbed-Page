using WordPressPCL.Models;

namespace XamarinGram.ViewModels
{
    public class MediaViewModel : MediaItem
    {
        public MediaSize Thumbnail
        {
            get
            {
                if (MediaDetails.Sizes.ContainsKey("thumbnail"))
                    return MediaDetails.Sizes["thumbnail"];
                else
                    return Medium;
            }
        }

        public MediaSize Medium
        {
            get
            {
                if (MediaDetails.Sizes.ContainsKey("medium"))
                    return MediaDetails.Sizes["medium"];
                else
                    return Large;
            }
        }

        public MediaSize Large
        {
            get
            {
                if (MediaDetails.Sizes.ContainsKey("large"))
                    return MediaDetails.Sizes["large"];
                else
                    return Full;
            }
        }

        public MediaSize Full
        {
            get
            {
                if (MediaDetails.Sizes.ContainsKey("full"))
                    return MediaDetails.Sizes["full"];
                else
                    return new MediaSize { SourceUrl = "http://www.turboday.com/img/img_not_available.jpg" };
            }
        }
    }
}
