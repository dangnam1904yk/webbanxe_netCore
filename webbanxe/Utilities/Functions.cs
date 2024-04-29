using System.Text.RegularExpressions;
using System.Text;
using webbanxe.Models;

namespace webbanxe.Utilities
{
    public class Functions
    {
        public static string TitleSlugGeneration(string type, string title, long id)
        {
            string sTitle = type + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
            return sTitle;
        }

        public static string TitleSlugGenerationReves(string type, long id, string title)
        {
            string sTitle = type + id.ToString() + "/" + SlugGenerator.SlugGenerator.GenerateSlug(title) + ".html";
            return sTitle;
        }


        public static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
    "đ",
    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
    "í","ì","ỉ","ĩ","ị",
    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
    "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
    "d",
    "e","e","e","e","e","e","e","e","e","e","e",
    "i","i","i","i","i",
    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
    "u","u","u","u","u","u","u","u","u","u","u",
    "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }

        public static string saveMutiImage(List<IFormFile> listImg)
        {
            string image = "";
            foreach (var file in listImg)
            {
                //   image += file.FileName + ";";
               
                string img_replace = file.FileName.Split(".")[0] + DateTime.Now.ToString("yyyyMMddHHmmss") + radomGenatorText()+"." + file.FileName.Split(".")[1];
                image += img_replace + ";";
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");

                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileNameWithPath = Path.Combine(path, img_replace);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            image = image.TrimEnd(';');

            return image;
        }


        public static void deleteMutiImage(string listImg)
        {
           
            foreach (var file in listImg)
            {
                foreach (var item in listImg.Split(";"))
                {
                    System.IO.File.Delete(Path.Combine
                        (Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img"), item));
                }
            }
        }

        public static string radomGenatorText()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[4];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        public static string saveSingleImage(IFormFile Img)
        {
            string img_replace = Img.FileName.Split(".")[0] + DateTime.Now.ToString("yyyyMMddHHmmss") + radomGenatorText() + "." + Img.FileName.Split(".")[1];

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fileNameWithPath = Path.Combine(path, img_replace);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                Img.CopyTo(stream);
            }
            return img_replace;
        }

        public static void deleteSingleImage(string Img)
        {
                    System.IO.File.Delete(Path.Combine
                        (Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img"), Img));
        }
    }
}
