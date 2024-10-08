﻿using dotnet_async.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_async.Client;
public class JornadaMilhasClient
{
    private HttpClient client;
    public JornadaMilhasClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<IEnumerable<Voo>> ConsultarVoos()
    {
        HttpResponseMessage response = await client.GetAsync("/Voos");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Voo>>();
    }

    public async Task<string> ComprarPassagem( CompraPassagemRequest request)
    {
        return await client.PostAsJsonAsync("/Voos/comprar", request).Result.Content.ReadFromJsonAsync<string>();

    }

}