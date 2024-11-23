public interface ITrafficLightState
{
    void Handle(TrafficLight context);
}
public class RedLightState : ITrafficLightState
{
    public void Handle(TrafficLight context)
    {
        Console.WriteLine("Красный свет: автомобили должны остановиться.");
        context.SetState(new YellowLightState());  // Переход на зеленый свет
    }
}
public class YellowLightState : ITrafficLightState
{
    public void Handle(TrafficLight context)
    {
        Console.WriteLine("Желтый свет: готовьтесь к изменению.");
        context.SetState(new GreenLightState());  // Переход на красный свет
    }
}
public class GreenLightState : ITrafficLightState
{
    public void Handle(TrafficLight context)
    {
        Console.WriteLine("Зеленый свет: пешеходы могут переходить.");
        context.SetState(new YellowLightState());  // Переход на желтый свет
    }
}
public class TrafficLight
{
    private ITrafficLightState _currentState;

    public TrafficLight()
    {
        // Начинаем с красного света
        _currentState = new RedLightState();
    }

    public void SetState(ITrafficLightState newState)
    {
        _currentState = newState;
    }

    public void ChangeLight()
    {
        _currentState.Handle(this);
    }
}
class Program
{
    static void Main()
    {

        TrafficLight trafficLight = new TrafficLight();

        trafficLight.ChangeLight();  // Красный свет -> Желтый свет
        trafficLight.ChangeLight();  // Желтый свет -> Зелёный свет
        trafficLight.ChangeLight();  // Зелёный свет -> Красный свет
    }
}
