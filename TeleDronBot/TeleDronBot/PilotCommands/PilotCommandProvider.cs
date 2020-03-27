﻿using System;
using System.Collections.Generic;
using System.Text;
using TeleDronBot.Base.BaseClass;
using TeleDronBot.PilotCommands.Callbacks;
using Telegram.Bot;

namespace TeleDronBot.PilotCommands
{
    class PilotCommandProvider : BaseCommandProvider
    {
        public PilotCommandProvider(TelegramBotClient client, MainProvider provider) : base(client, provider) { }

        private RegistrationPilotCommand _registrationCommand;
        private ShowOrders _showOrders;
        private RequestOfferCallBack _requestOffer;

        public RegistrationPilotCommand registrationCommand
        {
            get
            {
                if (_registrationCommand == null)
                    _registrationCommand = new RegistrationPilotCommand(client, provider);
                return _registrationCommand;
            }
        }

        public ShowOrders showOrder
        {
            get
            {
                if (_showOrders == null)
                    _showOrders = new ShowOrders(client, provider);
                return _showOrders;
            }
        }

        public RequestOfferCallBack requestOffer
        {
            get
            {
                if (_requestOffer == null)
                    _requestOffer = new RequestOfferCallBack(client, provider);
                return _requestOffer;
            }
        }
    }
}
