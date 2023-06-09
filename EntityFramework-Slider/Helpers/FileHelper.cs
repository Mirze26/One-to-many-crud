﻿using EntityFramework_Slider.Models;
using System.IO;

namespace EntityFramework_Slider.Helpers
{
    public static class FileHelper
    {                                            //file//                //image//
        public static bool CheckFileType(this IFormFile file, string pattern)
        {
            return file.ContentType.Contains(pattern);
        }

        public static bool CheckFileSize(this IFormFile file, long size)
        {
            return file.Length / 1024 < size;
        }

        public static void DeleteFile(string path)
        {
            if (File.Exists(path))            
                File.Delete(path);
            

        }


        public static string GetFilePath(string root, string folder, string file)
        {
            return Path.Combine(root, folder, file);                     // img folderin icinde bele bir sekil varsa onu sil //
        }


        public static async Task SaveFileAsync(string path, IFormFile file)
        {

            using (FileStream stream = new FileStream (path, FileMode.Create)) //Sonra gel Localda Image yarat
            {
                await file.CopyToAsync(stream);  // stream - bir axin(yayim,muhit)
            }

        }

    }
}

