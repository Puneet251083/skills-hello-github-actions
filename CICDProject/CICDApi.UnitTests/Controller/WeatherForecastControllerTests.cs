using CICDProject.Controllers;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace CICDProject.Tests;

[TestFixture]
public class WeatherForecastControllerTests
{
    private WeatherForecastController _controller;

    [SetUp]
    public void Setup()
    {
        _controller = new WeatherForecastController(
            NullLogger<WeatherForecastController>.Instance);
    }

    [Test]
    public void Get_ShouldReturnFiveRecords()
    {
        // Act
        var result = _controller.Get().ToList();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(5));
    }

    [Test]
    public void Get_ShouldReturnFutureDates()
    {
        // Act
        var result = _controller.Get().ToList();

        // Assert
        Assert.That(result.All(x => x.Date > DateOnly.FromDateTime(DateTime.Today)), Is.True);
    }

    [Test]
    public void Get_ShouldReturnValidTemperatureRange()
    {
        // Act
        var result = _controller.Get().ToList();

        // Assert
        Assert.That(result.All(x => x.TemperatureC >= -20 && x.TemperatureC < 55), Is.True);
    }

    [Test]
    public void Get_ShouldReturnValidSummary()
    {
        // Act
        var result = _controller.Get().ToList();

        // Assert
        Assert.That(result.All(x => !string.IsNullOrWhiteSpace(x.Summary)), Is.True);
    }
}