TIPOS DE INYECCION
Este proyecto muestra cómo funcionan los diferentes ciclos de vida de un servicio en .NET: **Transient**, **Scoped** y **Singleton**

---

## 1. Implementación de los Servicios

Creamos una **interfaz `IOrderService`** con los métodos principales:

- `AddOrder(Order order)` → agrega un pedido a la lista.
- `GetOrders()` → retorna todos los pedidos.
- `GetInstanceId()` → devuelve el Guid único de la instancia.
- `GetOrdersCount()` → cuenta los pedidos.

Luego implementamos la clase **`OrderService`** que:

- Genera un **Guid único** cada vez que se instancia.
- Mantiene una **lista interna de pedidos**.

En `Program.cs` registramos el servicio tres veces:

```csharp
builder.Services.AddTransient<IOrderService, OrderService>(); // nueva instancia cada vez
builder.Services.AddScoped<IOrderService, OrderService>();    // misma instancia por petición HTTP
builder.Services.AddSingleton<IOrderService, OrderService>(); // misma instancia para toda la aplicación
```
Comportamiento: Ejemplo en capturas de postman
Transient: nueva instancia siempre, no comparte datos.

Scoped: comparte datos solo dentro de la misma petición HTTP.

Singleton: comparte datos durante toda la vida de la aplicación.

Cuándo usar cada tipo de servicio

Transient: cada vez que alguien necesita el servicio, se crea uno nuevo. Por tanto es apto para cosas pequeñas y rápidas que no necesitan recordar nada.
Ejemplo: calcular la edad de alguien o dar formato a una fecha.

Scoped: el servicio dura solo mientras dura una acción o petición del usuario. Para cosas que necesitan recordar datos mientras el usuario hace algo, pero no después.
Ejemplo: un carrito de compras.

Singleton: hay una sola copia del servicio para toda la aplicación, todos lo usan y comparte los mismos datos.
Ejemplo: la configuración de la app, datos en caché.


## DIAGRAMA
# SINGLETON
Usuario A agrega pedido - lista = [Manzanas]
Usuario B ve la lista -lista = [Manzanas]
Usuario C agrega pedido - lista = [Manzanas, Peras]

# SCOPED
Solicitud 1 (Usuario A) agrega pedido - lista = [Manzanas]
Solicitud 1 GET - lista = [Manzanas]
Solicitud 2 (Usuario B) nueva solicitud - lista = []

# TRANSIENT
Solicitud 1 (Usuario A) agrega pedido - lista = [Manzanas]
Solicitud 1 GET - lista = [Manzanas]
Solicitud 2 (Usuario B) nueva solicitud - lista = []


