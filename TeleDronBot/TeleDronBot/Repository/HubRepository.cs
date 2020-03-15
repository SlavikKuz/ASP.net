﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeleDronBot.DTO;

namespace TeleDronBot.Repository
{
    class HubRepository : BaseRepository
    {
        private static GenericRepository<HubDTO> genericRepository;
        
        public HubRepository()
        {
            genericRepository = new GenericRepository<HubDTO>(db);
        }

        static HubRepository()
        {

        }

        public async Task ConfirmDialog(string confirm, long CreaterChatId, long ReceiverChatId)
        {
            if (confirm == "Start")
            {
                HubDTO reletedHub = new HubDTO(ReceiverChatId, CreaterChatId);
                await db.Hubs.AddAsync(reletedHub);
                await db.SaveChangesAsync();
                return;
            }
            else
            {
                HubDTO hub = await db.Hubs.FindAsync(CreaterChatId);
                db.Hubs.Remove(hub);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateDialog(long CreaterChatId, long ReceiverChatId)
        {
            HubDTO hub = await db.Hubs.FindAsync(CreaterChatId);
            if (hub == null)
            {
                hub = new HubDTO(CreaterChatId, ReceiverChatId);
                await db.Hubs.AddAsync(hub);
                await db.SaveChangesAsync();
                return;
            }
            hub.ChatIdReceiver = ReceiverChatId;
            db.Entry(hub).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}