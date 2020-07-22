﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Artes.Models
{
    public class UserLoginModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail de Acesso")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
    }

    public class UserRegistrationModel
    {
        [Required(ErrorMessage = "Informe o Nome de Usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o E-mail de Acesso")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Informe a Senha de Acesso")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Senha de Confirmação")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "A senha e a confirmação devem ser iguais")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Perfil de Acesso")]
        [Required(ErrorMessage = "Informe o Perfil de Acesso")]
        public string Perfis { get; set; }
    }

    public class UserViewModel
    {
        [HiddenInput]
        public string Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome de Usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o E-mail de Acesso")]
        [EmailAddress(ErrorMessage = "Informe um E-mail válido")]
        public string Email { get; set; }

        [Display(Name = "Perfil de Acesso")]
        [Required(ErrorMessage = "Informe o Perfil de Acesso")]
        public string Perfil { get; set; }
    }

    public class ForgotPasswordModel
    {

        [Display(Name = "E-mail de Acesso")]
        [Required(ErrorMessage = "Informe o E-mail de Acesso")]
        [EmailAddress(ErrorMessage = "Informe um E-mail válido")]
        public string Email { get; set; }

    }


    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "Informe a Nova Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmação de Senha")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "A Nova Senha e Confirmação de Senha não conferem")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }
    }


    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationModel, Usuario>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
