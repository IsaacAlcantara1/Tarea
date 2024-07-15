global using Xunit;

public class MaquinaDeCafeTests
{
    [Fact]
    public void Should_ReturnFelicitaciones_When_ResourcesAreEnough()
    {
        // Arrange
        var cafetera = new Cafetera(50);
        var vasoPequeno = new Vaso(5, 10);
        var azucarero = new Azucarero(20);

        var maquina = new MaquinaDeCafe();
        maquina.setCafetera(cafetera);
        maquina.setVasosPequeno(vasoPequeno);
        maquina.setAzucarero(azucarero);

        // Act
        var resultado = maquina.getVasoDeCafe(vasoPequeno, 1, 10);

        // Assert
        Assert.Equal("Felicitaciones", resultado);
    }

    [Fact]
    public void Should_ReturnNoHayVasos_When_InsufficientVasos()
    {
        // Arrange
        var cafetera = new Cafetera(50);
        var vasoPequeno = new Vaso(0, 10); // No hay vasos
        var azucarero = new Azucarero(20);

        var maquina = new MaquinaDeCafe();
        maquina.setCafetera(cafetera);
        maquina.setVasosPequeno(vasoPequeno);
        maquina.setAzucarero(azucarero);

        // Act
        var resultado = maquina.getVasoDeCafe(vasoPequeno, 1, 10);

        // Assert
        Assert.Equal("No hay Vasos", resultado);
    }

    [Fact]
    public void Should_ReturnNoHayCafe_When_InsufficientCafe()
    {
        // Arrange
        var cafetera = new Cafetera(5); // Insuficiente café
        var vasoPequeno = new Vaso(5, 10);
        var azucarero = new Azucarero(20);

        var maquina = new MaquinaDeCafe();
        maquina.setCafetera(cafetera);
        maquina.setVasosPequeno(vasoPequeno);
        maquina.setAzucarero(azucarero);

        // Act
        var resultado = maquina.getVasoDeCafe(vasoPequeno, 1, 10);

        // Assert
        Assert.Equal("No hay Cafe", resultado);
    }

    [Fact]
    public void Should_ReturnNoHayAzucar_When_InsufficientAzucar()
    {
        // Arrange
        var cafetera = new Cafetera(50);
        var vasoPequeno = new Vaso(5, 10);
        var azucarero = new Azucarero(5); // Insuficiente azúcar

        var maquina = new MaquinaDeCafe();
        maquina.setCafetera(cafetera);
        maquina.setVasosPequeno(vasoPequeno);
        maquina.setAzucarero(azucarero);

        // Act
        var resultado = maquina.getVasoDeCafe(vasoPequeno, 1, 10);

        // Assert
        Assert.Equal("No hay Azucar", resultado);
    }

    [Fact]
    public void Should_DecreaseCafeAndAzucar_When_CoffeeIsServed()
    {
        // Arrange
        var cafetera = new Cafetera(50);
        var vasoPequeno = new Vaso(5, 10);
        var azucarero = new Azucarero(20);

        var maquina = new MaquinaDeCafe();
        maquina.setCafetera(cafetera);
        maquina.setVasosPequeno(vasoPequeno);
        maquina.setAzucarero(azucarero);

        // Act
        var resultado = maquina.getVasoDeCafe(vasoPequeno, 1, 10);

        // Assert
        Assert.Equal("Felicitaciones", resultado);
        Assert.Equal(40, cafetera.getCantidadCafe());
        Assert.Equal(10, azucarero.getCantidadAzucar());
        Assert.Equal(4, vasoPequeno.getCantidadVasos());
    }
}