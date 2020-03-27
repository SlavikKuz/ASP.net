﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TeleDronBot.Base.BaseClass
{
    class BaseCommand
    {
        protected TelegramBotClient client;
        protected MainProvider provider;

        public BaseCommand(TelegramBotClient client, MainProvider provider)
        {
            this.client = client;
            this.provider = provider;
        }

        public virtual Task Request(long chatid)
        {
            throw new System.Exception("Method has to be override");
        }
    }
}
