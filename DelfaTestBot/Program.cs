using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace DelfaTestBot
{
    class Program
    {
        private static string token { get; set; } = "5183249647:AAHCx42xlNoIEZ51EXA2qo0lJe0e4mp_J4M";
        private static TelegramBotClient client;
        public static int Counter = 1;

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
            var name = msg.From.FirstName + " " + msg.From.LastName;
            Console.WriteLine(name);
            if (msg.Text.ToLower() == "cтарт" || msg.Text.ToLower() == "пройти тест заново" || msg.Text.ToLower() == "start" || msg.Text.ToLower() == "/start" || (msg.Text.ToLower() == "вернуться к прошлому вопросу" && Counter == 1))
            {
                Console.WriteLine("Пришло сообщение: " + msg.Text);
                await client.SendTextMessageAsync(msg.Chat.Id, "Вопрос 1:\nВам больше 18 лет?", replyMarkup: StartButtons());
                Counter = 0;
            }
            if (msg.Text.ToLower() == "больше или ровно 18" || (msg.Text.ToLower() == "вернуться к прошлому вопросу" && Counter == 2))
            {
                Console.WriteLine("Пришел ответ на вопрос: " + msg.Text);
                await client.SendTextMessageAsync(msg.Chat.Id, "Вопросов пройдено: 1\n(Количество вопросов может меняться в зависимости от ответов)");
                await client.SendTextMessageAsync(msg.Chat.Id, "Вопрос 2:\nКакие науки вы предпочитаете больше: Гуманитарные или Точные(Технарские)?", replyMarkup: Question2Buttons());
                Counter = 1;
            }
            if (msg.Text.ToLower() == "меньше 18")
            {
                Console.WriteLine("Пришел ответ на вопрос: " + msg.Text);
                await client.SendTextMessageAsync(msg.Chat.Id, "Вопросов пройдено: 1\n(Количество вопросов может меняться в зависимости от ответов)");
                await client.SendTextMessageAsync(msg.Chat.Id, "Вопрос 2:\nКакие науки вы предпочитаете больше: Гуманитарные или Точные(Технарские)?", replyMarkup: Question2Buttons());
                Counter = 1;
            }
            if (msg.Text.ToLower() == "гуманитарные" || (msg.Text.ToLower() == "вернуться к прошлому вопросу" && Counter == 3))
            {
                Console.WriteLine("Пришел ответ на вопрос: " + msg.Text);
                await client.SendTextMessageAsync(msg.Chat.Id, "Вопросов пройдено: 2");
                await client.SendTextMessageAsync(msg.Chat.Id, "Вопрос 3:\nВы любите работать с людьми?", replyMarkup: Question4Buttons());
                Counter = 2;
            }
            if (msg.Text.ToLower() == "да" || (msg.Text.ToLower() == "вернуться к прошлому вопросу" && Counter == 4))
            {
                Console.WriteLine("Пришел ответ на вопрос: " + msg.Text);
                await client.SendTextMessageAsync(msg.Chat.Id, "Вопросов пройдено: 3");
                await client.SendTextMessageAsync(msg.Chat.Id, "Вопрос 4:\nНравится ли вам учить детей?", replyMarkup: Question3Buttons());
                Counter = 3;
            }
            if (msg.Text.ToLower() == "нравится" || (msg.Text.ToLower() == "вернуться к прошлому вопросу" && Counter == 5))
            {
                Console.WriteLine("Пришел ответ на вопрос: " + msg.Text);
                await client.SendTextMessageAsync(msg.Chat.Id, "Вопросов пройдено: 4");
                await client.SendTextMessageAsync(msg.Chat.Id, $"Успешно!\nВы прирождённый преподаватель!😉\nВероятней всего вам подойдёт профессия Младшего воспитателя🏫\nСсылка на профессию на нашем портале:{"https://delfa72.ru/kursy/it-professii/obrazovaniie/mladshiy-vospitatel/"}", replyMarkup: EmptyAnsver());
                Counter = 4;
            }
            if (msg.Text.ToLower() == "не нравится" || (msg.Text.ToLower() == "вернуться к прошлому вопросу" && Counter == 5))
            {
                Console.WriteLine("Пришел ответ на вопрос: " + msg.Text);
                await client.SendTextMessageAsync(msg.Chat.Id, "Вопросов пройдено: 4");
                await client.SendTextMessageAsync(msg.Chat.Id, "Вопрос 5:\nХотите ли вы преображать людей?", replyMarkup: Question5Buttons());
                Counter = 4;
            }
            if (msg.Text.ToLower() == "хочу")
            {
                Console.WriteLine("Пришел ответ на вопрос: " + msg.Text);
                await client.SendTextMessageAsync(msg.Chat.Id, "Вопросов пройдено: 5");
                await client.SendTextMessageAsync(msg.Chat.Id, $"Успешно!\nМы уверены, что в ваших руках все станут прекрасными!😉\nВероятней всего вам подойдёт профессия Косметик-эстетиста💇\nСсылка на профессию на нашем портале:{"https://delfa72.ru/kursy/it-professii/servis-i-bytovye-uslugi/kosmetik-estetist/"}", replyMarkup: EmptyAnsver());
                Counter = 5;
            }
            if (msg.Text.ToLower() == "не хочу")
            {
                Console.WriteLine("Пришел ответ на вопрос: " + msg.Text);
                await client.SendTextMessageAsync(msg.Chat.Id, "Вопросов пройдено: 5");
                await client.SendTextMessageAsync(msg.Chat.Id, "Вопрос 6:\nЖелаете ли вы управлять персоналом, нанимать новые кадры?", replyMarkup: Question6Buttons());
                Counter = 5;
            }
            if (msg.Text.ToLower() == "желаю")
            {
                Console.WriteLine("Пришел ответ на вопрос: " + msg.Text);
                await client.SendTextMessageAsync(msg.Chat.Id, "Вопросов пройдено: 6");
                await client.SendTextMessageAsync(msg.Chat.Id, $"Успешно!\nУ вас сильно выражены лидерские качества!😉\nВероятней всего вам подойдут профессии связанные с административным персоналом" +
                    $"\nВыберите профессию по-душе:", replyMarkup: Question7Buttons());
            }
            if (msg.Text.ToLower() == "секретарь-администратор")
            {
                Console.WriteLine("Пришел ответ на вопрос: " + msg.Text);
                await client.SendTextMessageAsync(msg.Chat.Id, $"Успешно!\nАлексей Алексеич, к вам посетитель! Спасибо{name}!😉\nВероятней всего вам подойдёт профессия Секретаря-администратора📝\nСсылка на профессию на нашем портале:{"https://delfa72.ru/kursy/professionalnye-otrasli/administrativnyy-personal/sekretar-administrator/"}", replyMarkup: EmptyAnsver());
            }
            if (msg.Text.ToLower() == "хочу")
            {
                Console.WriteLine("Пришел ответ на вопрос: " + msg.Text);
                await client.SendTextMessageAsync(msg.Chat.Id, $"Успешно!\nМы уверены, что в ваших руках все станут прекрасными!😉\nВероятней всего вам подойдёт профессия Косметик-эстетиста💇\nСсылка на профессию на нашем портале:{"https://delfa72.ru/kursy/it-professii/servis-i-bytovye-uslugi/kosmetik-estetist/"}", replyMarkup: EmptyAnsver());
            }
            if (msg.Text.ToLower() == "хочу")
            {
                Console.WriteLine("Пришел ответ на вопрос: " + msg.Text);
                await client.SendTextMessageAsync(msg.Chat.Id, $"Успешно!\nМы уверены, что в ваших руках все станут прекрасными!😉\nВероятней всего вам подойдёт профессия Косметик-эстетиста💇\nСсылка на профессию на нашем портале:{"https://delfa72.ru/kursy/it-professii/servis-i-bytovye-uslugi/kosmetik-estetist/"}", replyMarkup: EmptyAnsver());
            }
            if (msg.Text.ToLower() == "хочу")
            {
                Console.WriteLine("Пришел ответ на вопрос: " + msg.Text);
                await client.SendTextMessageAsync(msg.Chat.Id, $"Успешно!\nМы уверены, что в ваших руках все станут прекрасными!😉\nВероятней всего вам подойдёт профессия Косметик-эстетиста💇\nСсылка на профессию на нашем портале:{"https://delfa72.ru/kursy/it-professii/servis-i-bytovye-uslugi/kosmetik-estetist/"}", replyMarkup: EmptyAnsver());
            }
            if (msg.Text.ToLower() == "хочу")
            {
                Console.WriteLine("Пришел ответ на вопрос: " + msg.Text);
                await client.SendTextMessageAsync(msg.Chat.Id, $"Успешно!\nМы уверены, что в ваших руках все станут прекрасными!😉\nВероятней всего вам подойдёт профессия Косметик-эстетиста💇\nСсылка на профессию на нашем портале:{"https://delfa72.ru/kursy/it-professii/servis-i-bytovye-uslugi/kosmetik-estetist/"}", replyMarkup: EmptyAnsver());
            }
            if (msg.Text.ToLower() == "хочу")
            {
                Console.WriteLine("Пришел ответ на вопрос: " + msg.Text);
                await client.SendTextMessageAsync(msg.Chat.Id, $"Успешно!\nМы уверены, что в ваших руках все станут прекрасными!😉\nВероятней всего вам подойдёт профессия Косметик-эстетиста💇\nСсылка на профессию на нашем портале:{"https://delfa72.ru/kursy/it-professii/servis-i-bytovye-uslugi/kosmetik-estetist/"}", replyMarkup: EmptyAnsver());
            }
        }

        private static IReplyMarkup StartButtons()
        {
            //WebClient web = new WebClient();
            //Byte[] Data = web.DownloadData(""); //Загрузка страницы для вывода кнопок с сайта в бота

            //using (FileStream file = new FileStream(@"C:\Users\Public\Music\t.txt", FileMode.Create))
            //{
            //    Byte[] vs = Data;

            //    file.Write(vs, 0, vs.Length);
            //}

            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Больше или ровно 18" }, new KeyboardButton { Text = "Меньше 18" } }
                }
            };
        }
        private static IReplyMarkup Question2Buttons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Гуманитарные" }, new KeyboardButton { Text = "Точные" } },
                    new List<KeyboardButton> { new KeyboardButton { Text = "Вернуться к прошлому вопросу" } }
                }
            };
        }
        private static IReplyMarkup Question3Buttons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Нравится" }, new KeyboardButton { Text = "Не нравится" } },
                    new List<KeyboardButton> { new KeyboardButton { Text = "Вернуться к прошлому вопросу" } }
                }
            };
        }
        private static IReplyMarkup Question4Buttons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Да" }, new KeyboardButton { Text = "Нет" } },
                    new List<KeyboardButton> { new KeyboardButton { Text = "Вернуться к прошлому вопросу" } }
                }
            };
        }
        private static IReplyMarkup EmptyAnsver()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Вернуться к прошлому вопросу" }, new KeyboardButton { Text = "Пройти тест заново" } }
                }
            };
        }
        private static IReplyMarkup Question5Buttons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Хочу" }, new KeyboardButton { Text = "Не хочу" } },
                    new List<KeyboardButton> { new KeyboardButton { Text = "Вернуться к прошлому вопросу" } }
                }
            };
        }
        private static IReplyMarkup Question6Buttons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Желаю" }, new KeyboardButton { Text = "Не желаю" } },
                    new List<KeyboardButton> { new KeyboardButton { Text = "Вернуться к прошлому вопросу" } }
                }
            };
        }
        private static IReplyMarkup Question7Buttons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Секретарь-администратор" }, new KeyboardButton { Text = "Офис-менеджер" } },
                    new List<KeyboardButton> { new KeyboardButton { Text = "Архивариус" }, new KeyboardButton { Text = "Делопроизводитель" } },
                    new List<KeyboardButton> { new KeyboardButton { Text = "Специалист по кадровому делопроизводству" }, new KeyboardButton { Text = "Рекрутер" } }
                }
            };
        }
    }
}
