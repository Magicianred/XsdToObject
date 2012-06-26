﻿using System.IO;
using System.Linq;
using System.Xml.Linq;
using AutoGenerated;
using NUnit.Framework;

namespace SevenDigital.Parsing.XsdToObject.Tests
{
    [TestFixture]
    public class AutoGeneratedClassesTest
    {
        private Vehicles _vehicles;

        [SetUp]
        public void SetUp()
        {
            XDocument doc = XDocument.Load(Path.Combine("res", "xml.xml"));
            _vehicles = new Vehicles(doc.Elements().Single(e => e.Name == "vehicles"));
        }

        [Test]
        public void ShouldBeNotNull()
        {
            Assert.That(_vehicles, Is.Not.Null);
        }

        [Test]
        public void ShouldHaveBMW()
        {
            Car car = _vehicles.Cars.Single(c => c.Brand == "BMW");
            Assert.That(car.Color.Hue,Is.EqualTo("black"));
            Assert.That(car.Color.Rgb,Is.Null);
        }

        [Test]
        public void ShouldHaveHonda()
        {
            Car car = _vehicles.Cars.Single(c => c.Brand == "Honda");
            Assert.That(car.Color.Hue, Is.EqualTo("red"));
            Assert.That(car.Color.Rgb, Is.EqualTo("0xff0000"));
        }
    }
}
