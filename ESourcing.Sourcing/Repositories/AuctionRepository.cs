﻿using ESourcing.Sourcing.Data.Interface;
using ESourcing.Sourcing.Entities;
using ESourcing.Sourcing.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace ESourcing.Sourcing.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private ISourcingContext _context;
        public AuctionRepository(ISourcingContext context)
        {
            _context = context;
        }

        public async Task Create(Auction auction)
        {
            await _context.Auctions.InsertOneAsync(auction);
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Auction> filter = Builders<Auction>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _context.Auctions.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Auction> GetAuction(string id)
        {
            return await _context.Auctions.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Auction> GetAuctionByName(string name)
        {
            FilterDefinition<Auction> filter = Builders<Auction>.Filter.Eq(m => m.Name, name);

            return await _context.Auctions.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Auction>> GetAuctions()
        {
            return await _context.Auctions.Find(a => true).ToListAsync();
        }

        public async Task<bool> Update(Auction auction)
        {
            var updateResult = await _context.Auctions.ReplaceOneAsync(a => a.Id.Equals(auction.Id), auction);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
