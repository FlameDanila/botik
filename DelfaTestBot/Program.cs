using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace DelfaTestBot
{
    class Program
    {
        private static string token { get; set; } = "5183249647:AAHCx42xlNoIEZ51EXA2qo0lJe0e4mp_J4M";
        private static TelegramBotClient client;

        [Obsolete]
        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }

        [Obsolete]
        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine("Пришло сообщение: " + msg.Text);
                await client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyMarkup: GetButtons());
            }
        }

        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Привет" }, new KeyboardButton { Text = "aaa" } },
                    new List<KeyboardButton> { new KeyboardButton { Text = "Пока" } }
                }
            };
        }
    }
}
