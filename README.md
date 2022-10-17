# GodelTech.Business.AutoMapper

Library for using AutoMapper with GodelTech.Business

## Overview
`GodelTech.Business.AutoMapper` implements [GodelTech.Business](https://github.com/GodelTech/GodelTech.Business) `IBusinessMapper` interface using [AutoMapper](https://www.nuget.org/packages/AutoMapper) NuGet package. It allows to use mapping of `TSource` to `TDestination`.

```csharp
public class BusinessMapper : IBusinessMapper
{
    private readonly IMapper _mapper;

    public BusinessMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TDestination Map<TSource, TDestination>(TSource source)
    {
        return _mapper.Map<TSource, TDestination>(source);
    }

    public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
    {
        return _mapper.Map(source, destination);
    }
}
```