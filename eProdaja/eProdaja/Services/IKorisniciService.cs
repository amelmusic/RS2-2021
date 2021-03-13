﻿using eProdaja.Database;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public interface IKorisniciService
    {
        List<Model.Korisnici> Get();

        Model.Korisnici Insert(KorisniciInsertRequest request);
    }
}
