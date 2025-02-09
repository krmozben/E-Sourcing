﻿using ESourcing.Sourcing.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace ESourcing.Sourcing.Data
{
    public class SourcingContextSeed
    {
        public static void SeedData(IMongoCollection<Auction> auctionCoolection)
        {
            bool exist = auctionCoolection.Find(p => true).Any();

            if (!exist)
            {
                auctionCoolection.InsertManyAsync(GetPreconfiguredAuctions());
            }
        }

        private static IEnumerable<Auction> GetPreconfiguredAuctions()
        {
            return new List<Auction>()
            {
                new Auction(){
                    Name ="Auction 1",
                    Description="Auction Desc 1",
                    CreatedAt = DateTime.Now,
                    StartedAt = DateTime.Now,
                    FinishedAt = DateTime.Now.AddDays(10),
                    ProductId = "609bcd5aa97d955de2d195e4",
                    IncludedSellers = new List<string>()
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com",
                    },
                    Quantity = 5,
                    Status = (int)Status.Active
                },
                new Auction(){
                    Name ="Auction 2",
                    Description="Auction Desc 2",
                    CreatedAt = DateTime.Now,
                    StartedAt = DateTime.Now,
                    FinishedAt = DateTime.Now.AddDays(10),
                    ProductId = "609bcd5aa97d955de2d195e4",
                    IncludedSellers = new List<string>()
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com",
                    },
                    Quantity = 5,
                    Status = (int)Status.Active
                },
                new Auction(){
                    Name ="Auction 3",
                    Description="Auction Desc 3",
                    CreatedAt = DateTime.Now,
                    StartedAt = DateTime.Now,
                    FinishedAt = DateTime.Now.AddDays(10),
                    ProductId = "609bcd5aa97d955de2d195e4",
                    IncludedSellers = new List<string>()
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com",
                    },
                    Quantity = 5,
                    Status = (int)Status.Active
                }
            };
        }
    }
}