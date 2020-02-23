// Copyright @JJSoft - All Rights Reserved
// Filename: MergeFruitRequest.cs
// Created By  :  Frankie
// Created Date:  23/02/2020  10:39
// Last Edit:
//    Author:   Frankie
//    Date:     23/02/2020  10:58

namespace GroceryServer.Admin.Requests
{
    using System.Collections.Generic;

    using GroceryServer.Admin.DtoModels;
    using GroceryServer.Infrastructure.ConsumerStructure.Interfaces;

    public class MergeFruitRequest : IRequest
    {
        public List<FruitDto> Fruits { get; set; }
    }
}