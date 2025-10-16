using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using Maui.PDFView;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using PdfSharp.Fonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfFormDemo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            // Initialize PDFsharp font resolver
            GlobalFontSettings.FontResolver = new PdfFormFramework.Services.SystemFontResolver();

            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                .UseMauiPdfView()
                .UseMauiCommunityToolkit();
            builder.Services.AddSingleton<IFileSaver>(FileSaver.Default);

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}