﻿using System.Security.Cryptography;
using System.Text;
using Vendr.Core.Models;
using Vendr.Extensions;

namespace Vendr.PaymentProviders.Opayo
{
    public static class StringExtensions
    {

        public static string Truncate(this string self, int length)
        {
            if (string.IsNullOrWhiteSpace(self)) return self;
            if (self.Length <= length) return self;
            return self.Substring(0, length);
        }

        internal static string ReplacePlaceHolders(this string self, OrderReadOnly order)
        {
            return self.Replace(OpayoConstants.PlaceHolders.OrderReference, order.GenerateOrderReference().OrderNumber)
                .Replace(OpayoConstants.PlaceHolders.OrderId, order.Id.ToString());
        }

        public static string ToMD5Hash(this string input)
        {
            return (new MD5CryptoServiceProvider()).ComputeHash(Encoding.UTF8.GetBytes(input)).ToHex();
        }
    }
}
