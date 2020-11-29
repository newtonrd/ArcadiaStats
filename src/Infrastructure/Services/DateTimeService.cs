using ArcadiaStats.Application.Common.Interfaces;
using System;

namespace ArcadiaStats.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
