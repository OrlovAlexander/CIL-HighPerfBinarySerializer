
This project shows how using .NET CIL you can auto generate serialization surrogates on the fly. Here are the basic steps:

Define a custom attribute that you can use to tag the class you want to generate serialization surrogates for.
During the startup of your assembly, walk through all the types that have this custom attribute and generate a serialization surrogate for them.
Create a class with an interface similar to the binary formatter that internally delegates the call to the IL serialization surrogate.

See the comlete instructions at
http://www.codeproject.com/Articles/151946/A-High-Performance-Binary-Serializer-using-Microso
