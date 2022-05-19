using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using TL;

namespace DelfaTestBot
{
    class Program
    {
        private static string token { get; set; } = "5183249647:AAHCx42xlNoIEZ51EXA2qo0lJe0e4mp_J4M";
        private static TelegramBotClient client;
        public static int Counter = 1;
        public static long chatId = 0;

        [Obsolete]
        static async Task Main(string[] args)
        {
            static string Config(string what)
            {
                switch (what)
                {
                    case "api_id": return "17257489";
                    case "api_hash": return "1c8608e262882c49cb57d1640b46b559";
                    case "phone_number": return "+79504951460";
                    case "verification_code": Console.Write("Code: "); return Console.ReadLine();
                    case "first_name": return "Danila";      // if sign-up is required
                    case "last_name": return ".";        // if sign-up is required
                    case "password": return "secret!";     // if user has enabled 2FA
                    default: return null;                  // let WTelegramClient decide the default config
                }
            }

            string file = File.ReadAllText("numbers.txt");
            string[] mass = file.Split(',');
            for (int i = 0; i < mass.Count(); i++)
            {
                Console.WriteLine(mass[i].ToString());
                using var wTLClient = new WTelegram.Client(Config);
                var my = await wTLClient.LoginUserIfNeeded();
                Console.WriteLine($"We are logged-in as {my.username ?? my.first_name + " " + my.last_name} (id {my.id})");
                try
                {
                    var resolved = await wTLClient.Contacts_ResolvePhone($"{mass[i]}"); // username without the @
                    await wTLClient.SendMessageAsync(resolved, "Привет, это автоматическое сообщение всем клиентам Delfa, пожалуйста, пройдите тест для улучшения качества обслуживания.\nЧтобы пройти тест - напишите этому боту: @DelfaTestBot");
                }
                catch (Exception ex)
                { }
            }
        }
    }
}