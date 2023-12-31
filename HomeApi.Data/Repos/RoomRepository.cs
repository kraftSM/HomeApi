﻿using System;
using System.Linq;
using System.Threading.Tasks;
using HomeApi.Data.Models;
using HomeApi.Data.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HomeApi.Data.Repos
{
    /// <summary>
    /// Репозиторий для операций с объектами типа "Room" в базе
    /// </summary>
    public class RoomRepository : IRoomRepository
    {
        private readonly HomeApiContext _context;
        
        public RoomRepository (HomeApiContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Получить все комнаты
        /// </summary>
        public async Task<Room[]> GetRooms()
        {
            return await _context.Rooms.ToArrayAsync();
        }
        /// <summary>
         ///  Найти комнату по имени
         /// </summary>
        public async Task<Room> GetRoomByName(string name)
        {
            return await _context.Rooms.Where(r => r.Name == name).FirstOrDefaultAsync();
        }
        /// <summary>
        /// Найти комнату по идентификатору
        /// </summary>
        public async Task<Room> GetRoomById(Guid id)
        {
            return await _context.Rooms
                .Where(d => d.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        ///  Добавить новую комнату
        /// </summary>
        public async Task AddRoom(Room room)
        {
            var entry = _context.Entry(room);
            if (entry.State == EntityState.Detached)
                await _context.Rooms.AddAsync(room);
            
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Обновить существующее устройство
        /// </summary>
        public async Task UpdateRoom( Room room, UpdateRoomQuery query)
        {
            //Room = room.Id;

            // Если в запрос переданы параметры для обновления - проверяем их на null
            // И если нужно - обновляем устройство
            if (!string.IsNullOrEmpty(query.NewName))
                room.Name = query.NewName;
            // проверку (для INT) <> IsNotNull предварительно сделалием в классе валидации ввода
            if (query.NewArea >0) 
                room.Area = query.NewArea;
            if (query.NewVoltage> 0)
                room.Voltage = query.NewVoltage;
            // проверку (для bollean)  IsNotNull предварительно сделалием в классе валидации ввода
            //var strBoolVal = query.NewGasConnected.ToString().ToLower();
            if (query.NewGasConnected) room.GasConnected = true;
            else room.GasConnected = false;

            // Добавляем в базу 
            var entry = _context.Entry(room);
            if (entry.State == EntityState.Detached)
                _context.Rooms.Update(room);

            // Сохраняем изменения в базе 
            await _context.SaveChangesAsync();
        }
    }
}