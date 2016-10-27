﻿using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Kartverket.FinnPosisjon.Models;
using Kartverket.FinnPosisjon.Services;
using Xunit;

namespace Kartverket.FinnPosisjon.Tests
{
    public class PositionFinderTest
    {
        private static readonly PositionFinder PositionFinder = new PositionFinder
        {
            SupportedCoordinateSystems = CoordinateSystemsSetup.Get()
        };

        [Fact (Skip= "Unknown problem")]
        public void ShouldFindPositionWithCoordSysEu89UtmZone33()
        {
            var coordinates = new Coordinates {X = 288889.7639, Y = 7231445.376};

            var positions = PositionFinder.Find(new List<Coordinates> {coordinates});

            positions.Any(p => p.CoordinateSystem.Name == "EUREF89, UTM-sone 33").Should().BeTrue();
        }
    }
}
