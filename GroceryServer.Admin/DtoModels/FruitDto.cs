// Copyright @JJSoft - All Rights Reserved
// Filename: FruitDto.cs
// Created By  :  Frankie
// Created Date:  23/02/2020  09:49
// Last Edit:
//    Author:   Frankie
//    Date:     23/02/2020  11:21

namespace GroceryServer.Admin.DtoModels
{
    using System;

    using GroceryServer.Infrastructure.Helpers;

    public class FruitDto
    {
        public int Id { get; set; }

        [TvpAttr]
        public string Fruit { get; set; }

        [TvpAttr]
        public decimal Price { get; set; }

        [TvpAttr]
        public int Quantity { get; set; }

        [TvpAttr]
        public DateTime UpdatedDate { get; set; }
    }
}