function GetUrl(type)
{
    var url='';
    switch (type)

    {
        case 'url':
            url = window.location.href;
            break;
        case 'protocol':
            url = window.location.protocol;
            break;
        case 'host':
            url = window.location.host;
            break;
        case 'port':
            url = window.location.port;
            break;
        case 'pathname':
            url = window.location.pathname;
            break;
        case 'search':
            url = window.location.search;
            break;
        case 'hash':
            url = window.location.hash;
            break;
    }


    return url;

}






