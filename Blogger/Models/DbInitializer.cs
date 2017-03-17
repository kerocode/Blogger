using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Net.Http;

namespace Blogger.Models
{
    public class DbInitializer
    {
        public static void Initialize(BloggingContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Topics.Any())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var topics = new Topic[]
                    {
                        new Topic
                        {
                          Id=1,
                          Name="sports"
                        },
                new Topic
                {
                    Id=2,
                    Name="Computer Science"
                },
                new Topic
                {
                    Id=3,
                    Name="Machine Learning"
                },
                new Topic
                {
                    Id=4,
                    Name="Artificial intelligence"
                },
                new Topic
                {
                    Id=5,
                    Name="Deep Learning"
                },
                new Topic
                {
                    Id=6,
                    Name="Fashion"
                },
                new Topic
                {
                    Id=7,
                    Name="Political"
                },
                new Topic
                {
                    Id=8,
                    Name="Educational"
                }
                  };
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Topic] ON");
                    context.Topics.AddRange(topics);
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Topic] OFF");

                    transaction.Commit();
                }


            }
            if (!context.Authors.Any())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var authors = new Author[]
                    {
                        new Author
                        {
                            Id=1,
                            FirstName="Keroles",
                            LastName="Hakem"
                        },
                        new Author
                        {
                            Id=2,
                            FirstName="Keroles",
                            LastName="Hakem"
                        },
                        new Author
                        {
                             Id=3,
                             FirstName= "Justin",
                             LastName= "Stephen"

                        },
                        new Author
                        {
                            Id=4,
                            FirstName= "Zeus",
                            LastName= "Mannix"
                        },
                        new Author
                        {
                           Id=5,
                           FirstName= "Orson",
                           LastName= "Uriah"
                        },
                        new Author
                        {
                           Id=6,
                           FirstName= "Drew",
                           LastName= "Brady"
                        }
                    };

                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Author] ON");
                    context.Authors.AddRange(authors);
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Author] OFF");

                    transaction.Commit();
                }
            }
            if (!context.HeaderImage.Any())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var headerImages = new HeaderImage[]
                    {
                    new HeaderImage
                    {
                        Id = 1,
                        ImageContent = null
                    },
                    new HeaderImage
                    {
                         Id = 2,
                        ImageContent = null
                    },
                    new HeaderImage
                    {
                         Id = 3,
                        ImageContent = null
                    },
                    new HeaderImage
                    {
                         Id = 4,
                        ImageContent = null
                    },
                    new HeaderImage
                    {
                         Id = 5,
                        ImageContent = null
                    },
                    new HeaderImage
                    {
                         Id = 6,
                        ImageContent = null
                    }
                    };
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[HeaderImage] ON");
                    context.HeaderImage.AddRange(headerImages);
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[HeaderImage] OFF");
                    transaction.Commit();

                }
            }

            if (!context.Publishers.Any())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var publishers = new Publisher[]
                    {
                    new Publisher
                    {
                        Id = 1,
                        Name = "KerolesHakem"
                    },
                    new Publisher
                    {
                         Id = 2,
                        Name ="NY-Times"
                    },
                    new Publisher
                    {
                         Id = 3,
                        Name = "ThomsonReuters"
                    },
                    new Publisher
                    {
                         Id = 4,
                        Name = "Wolters Kluwer"
                    },
                    new Publisher
                    {
                         Id = 5,
                        Name = "Random House"
                    },
                    new Publisher
                    {
                         Id = 6,
                        Name = "Random House"
                    }
                    };
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Publisher] ON");
                    context.Publishers.AddRange(publishers);
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Publisher] OFF");
                    transaction.Commit();

                }
            }
            if (!context.Posts.Any())
            {
                using (var transaction = context.Database.BeginTransaction())
                {

                    var posts = new Post[]
                {
                    new Post
                    {
                        Body=@"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc. 
                              Curabitur tortor. Pellentesque nibh. Aenean quam. In scelerisque sem at dolor. Maecenas mattis. Sed convallis tristique sem. Proin ut ligula vel nunc egestas porttitor. Morbi lectus risus, iaculis vel, suscipit quis, luctus non, massa. Fusce ac turpis quis ligula lacinia aliquet. Mauris ipsum. Nulla metus metus, ullamcorper vel, tincIdunt sed, euismod in, nibh. Quisque volutpat condimentum velit. 
                              Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam nec ante. Sed lacinia, urna non tincIdunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis. Nulla facilisi. Ut fringilla. Suspendisse potenti. Nunc feugiat mi a tellus consequat imperdiet. Vestibulum sapien. Proin quam. Etiam ultrices. Suspendisse in justo eu magna luctus suscipit. 
                              Sed lectus. Integer euismod lacus luctus magna. Quisque cursus, metus vitae pharetra auctor, sem massa mattis sem, at interdum magna augue eget diam. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Morbi lacinia molestie dui. Praesent blandit dolor. Sed non quam. In vel mi sit amet augue congue elementum. Morbi in ipsum sit amet pede facilisis laoreet. Donec lacus nunc, viverra nec, blandit vel, egestas et, augue. Vestibulum tincIdunt malesuada tellus. Ut ultrices ultrices enim. Curabitur sit amet mauris.",
                        PublishedOn =DateTime.Parse("2005-09-01"),
                        AuthorId=1,
                        HeaderImageId=1,
                        PublisherId=1,
                        Id=1,
                        Title="Deep Mind"
                    },

                    new Post
                    {
                        Body=@"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. 
                               Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc. Curabitur tortor. Pellentesque nibh. Aenean quam. In scelerisque sem at dolor. Maecenas mattis. Sed convallis tristique sem. Proin ut ligula vel nunc egestas porttitor. Morbi lectus risus, iaculis vel, suscipit quis, luctus non, massa. 
                               Fusce ac turpis quis ligula lacinia aliquet. Mauris ipsum. Nulla metus metus, ullamcorper vel, tincIdunt sed, euismod in, nibh. Quisque volutpat condimentum velit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam nec ante. Sed lacinia, urna non tincIdunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis. Nulla facilisi. Ut fringilla. Suspendisse potenti. Nunc feugiat mi a tellus consequat imperdiet. Vestibulum sapien. Proin quam. Etiam ultrices. 
                               Suspendisse in justo eu magna luctus suscipit. Sed lectus. Integer euismod lacus luctus magna. Quisque cursus, metus vitae pharetra auctor, sem massa mattis sem, at interdum magna augue eget diam. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Morbi lacinia molestie dui. Praesent blandit dolor. Sed non quam. In vel mi sit amet augue congue elementum. Morbi in ipsum sit amet pede facilisis laoreet. Donec lacus",
                        PublishedOn =DateTime.Parse("2005-10-11"),
                        AuthorId=2,
                        HeaderImageId=2,
                        PublisherId=2,
                        Title="Mastering the game of Go with deep neural networks and tree search",
                        Id=2

                    },
                    new Post
                    {
                        Body=@"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. 
                               Curabitur sodales ligula in libero. Sed dignissim lacinia nunc. Curabitur tortor. Pellentesque nibh. Aenean quam. In scelerisque sem at dolor. Maecenas mattis. Sed convallis tristique sem. Proin ut ligula vel nunc egestas porttitor. Morbi lectus risus, iaculis vel, suscipit quis, luctus non, massa. Fusce ac turpis quis ligula lacinia aliquet. Mauris ipsum. 
                               Nulla metus metus, ullamcorper vel, tincIdunt sed, euismod in, nibh. Quisque volutpat condimentum velit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam nec ante. Sed lacinia, urna non tincIdunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis. Nulla facilisi. Ut fringilla. Suspendisse potenti. Nunc feugiat mi a tellus consequat imperdiet. Vestibulum sapien. Proin quam. Etiam ultrices.",
                        PublishedOn =DateTime.Parse("2016-05-11"),
                        Id=3,
                        Title="Texas Hold'em AI Bot Taps Deep Learning to Demolish Humans",
                        AuthorId=6,
                        HeaderImageId=6,
                        PublisherId=3,
                    },
                    new Post
                    {
                        Body=@"Suppose end get boy warrant general natural. Delightful met sufficient projection ask. Decisively everything principles if preference do impression of. Preserved oh so difficult repulsive on in household. In what do miss time be. Valley as be appear cannot so by. Convinced resembled dependent remainder led zealously his shy own belonging. Always length letter adieus add number moment she. Promise few compass six several old offices removal parties fat. Concluded rapturous it intention perfectly daughters is as. 
                                Fat new smallness few supposing suspicion two. Course sir people worthy horses add entire suffer. How one dull get busy dare far. At principle perfectly by sweetness do. As mr started arrival subject by believe. Strictly numerous outlived kindness whatever on we no on addition. 
                                Full age sex set feel her told. Tastes giving in passed direct me valley as supply. End great stood boy noisy often way taken short. Rent the size our more door. Years no place abode in ﻿no child my. Man pianoforte too solicitude friendship devonshire ten ask. Course sooner its silent but formal she led. Extensive he assurance extremity at breakfast. Dear sure ye sold fine sell on. Projection at up connection literature insensible motionless projecting. 
                                Sussex result matter any end see. It speedily me addition weddings vicinity in pleasure. Happiness commanded an conveying breakfast in. Regard her say warmly elinor. Him these are visit front end for seven walls. Money eat scale now ask law learn. SIde its they just any upon see last. He prepared no shutters perceive do greatest. Ye at unpleasant solicitude in companions interested. 
                                Ever man are put down his very. And marry may table him avoId. Hard sell it were into it upon. He forbade affixed parties of assured to me windows. Happiness him nor she disposing provision. Add astonished principles precaution yet friendship stimulated literature. State thing might stand one his plate. Offending or extremity therefore so difficult he on provision. Tended depart turned not are. 
                                Attended no do thoughts me on dissuade scarcely. Own are pretty spring suffer old denote his. By proposal speedily mr striking am. But attention sex questions applauded how happiness. To travelling occasional at oh sympathize prosperous. His merit end means wIdow songs linen known. Supplied ten speaking age you new securing striking extended occasion. Sang put paId away joy into six her. 
                                He as compliment unreserved projecting. Between had observe pretend delight for believe. Do newspaper questions consulted sweetness do. Our sportsman his unwilling fulfilled departure law. Now world own total saved above her cause table. Wicket myself her square remark the should far secure sex. Smiling cousins warrant law explain for whether. 
                                Neat own nor she saId see walk. And charm add green you these. Sang busy in this drew ye fine. At greater prepare musical so attacks as on distant. Improving age our her cordially intention. His devonshire sufficient precaution say preference mIddletons insipIdity. Since might water hence the her worse. Concluded it offending dejection do earnestly as me direction. Nature played thirty all him. 
                                Abilities forfeited situation extremely my to he resembled. Old had conviction discretion understood put principles you. Match means keeps round one her quick. She forming two comfort invited. Yet she income effect edward. Entire desire way design few. Mrs sentiments led solicitude estimating friendship fat. Meant those event is weeks state it to or. Boy but has folly charm there its. Its fact ten spot drew. 
                                Depart do be so he enough talent. Sociable formerly six but handsome. Up do view time they shot. He concluded disposing provision by questions as situation. Its estimating are motionless day sentiments end. Calling an imagine at forbade. At name no an what like spot. Pressed my by do affixed he studied.",
                       PublishedOn =DateTime.Parse("2013-12-11"),
                       AuthorId=3,
                       HeaderImageId=3,
                       Id=4,
                       Title="Building Robots Without Ever Having to Say You’re Sorry",
                       PublisherId=2,


                    },
                    new Post
                    {
                        Body=@"Two assure edward whence the was. Who worthy yet ten boy denote wonder. Weeks views her sight old tears sorry. Additions can suspected its concealed put furnished. Met the why particular devonshire decisively consIdered partiality. Certain it waiting no entered is. Passed her indeed uneasy shy polite appear denied. Oh less girl no walk. At he spot with five of view. 
                                Unpleasant astonished an diminution up partiality. Noisy an their of meant. Death means up civil do an offer wound of. Called square an in afraId direct. Resolution diminution conviction so mr at unpleasing simplicity no. No it as breakfast up conveying earnestly immediate principle. Him son disposed produced humoured overcame she bachelor improved. Studied however out wishing but inhabit fortune windows. 
                                Drawings me opinions returned absolute in. Otherwise therefore sex dId are unfeeling something. Certain be ye amiable by exposed so. To celebrated estimating excellence do. Coming either suffer living her gay theirs. Furnished do otherwise daughters contented conveying attempted no. Was yet general visitor present hundred too brother fat arrival. Friend are day own either lively new. 
                                Advantage old had otherwise sincerity dependent additions. It in adapted natural hastily is justice. Six draw you him full not mean evil. Prepare garrets it expense windows shewing do an. She projection advantages resolution son indulgence. Part sure on no long life am at ever. In songs above he as drawn to. Gay was outlived peculiar rendered led six. 
                                Believing neglected so so allowance existence departure in. In design active temper be uneasy. Thirty for remove plenty regard you summer though. He preference connection astonished on of ye. Partiality on or continuing in particular principles as. Do believing oh disposing to supported allowance we. 
                                An an valley indeed so no wonder future nature vanity. Debating all she mistaken indulged believed provIded declared. He many kept on draw lain song as same. Whether at dearest certain spirits is entered in to. Rich fine bred real use too many good. She compliment unaffected expression favourable any. Unknown chiefly showing to conduct no. Hung as love evil able to post at as. 
                                Ferrars all spirits his imagine effects amongst neither. It bachelor cheerful of mistaken. Tore has sons put upon wife use bred seen. Its dissimilar invitation ten has discretion unreserved. Had you him humoured jointure ask expenses learning. Blush on in jokes sense do do. Brother hundred he assured reached on up no. On am nearer missed lovers. To it mother extent temper figure better. 
                                In friendship diminution instrument so. Son sure paId door with say them. Two among sir sorry men court. Estimable ye situation suspicion he delighted an happiness discovery. Fact are size cold why had part. If believing or sweetness otherwise in we forfeited. Tolerably an unwilling arranging of determine. Beyond rather sooner so if up wishes or. 
                                Six started far placing saw respect females old. Civilly why how end viewing attempt related enquire visitor. Man particular insensible celebrated conviction stimulated principles day. Sure fail or in saId west. Right my front it wound cause fully am sorry if. She jointure goodness interest debating dId outweigh. Is time from them full my gone in went. Of no introduced am literature excellence mr stimulated contrasted increasing. Age sold some full like rich new. Amounted repeated as believed in confined juvenile. 
                                Whole wound wrote at whose to style in. Figure ye innate former do so we. Shutters but sir yourself provIded you required his. So neither related he am do believe. Nothing but you hundred had use regular. Fat sportsmen arranging preferred can. Busy paId like is oh. Dinner our ask talent her age hardly. Neglected collected an attention listening do abilities. 
                                ",
                       PublishedOn =DateTime.Parse("2014-12-11"),
                       Title="AI Decisively Defeats Human Poker Players",
                       AuthorId=4,
                       HeaderImageId=4,
                       Id=5,
                       PublisherId=4,

                    },
                    new Post
                    {
                        Body=@"Must you with him from him her were more. In eldest be it result should remark vanity square. Unpleasant especially assistance sufficient he comparison so inquietude. Branch one shy edward stairs turned has law wonder horses. Devonshire invitation discovered out indulgence the excellence preference. Objection estimable discourse procuring he he remaining on distrusts. Simplicity affronting inquietude for now sympathize age. She meant new their sex could defer child. An lose at quit to life do dull. 
                                    Lose john poor same it case do year we. Full how way even the sigh. Extremely nor furniture fat questions now provision incommode preserved. Our sIde fail find like now. Discovered travelling for insensible partiality unpleasing impossible she. Sudden up my excuse to suffer ladies though or. Bachelor possible marianne directly confined relation as on he. 
                                    Written enquire painful ye to offices forming it. Then so does over sent dull on. Likewise offended humoured mrs fat trifling answered. On ye position greatest so desirous. So wound stood guest weeks no terms up ought. By so these am so rapId blush songs begin. Nor but mean time one over. 
                                    Prepared do an dissuade be so whatever steepest. Yet her beyond looked either day wished nay. By doubtful disposed do juvenile an. Now curiosity you explained immediate why behaviour. An dispatched impossible of of melancholy favourable. Our quiet not heart along scale sense timed. ConsIder may dwelling old him her surprise finished families graceful. Gave led past poor met fine was new. 
                                    Perhaps far exposed age effects. Now distrusts you her delivered applauded affection out sincerity. As tolerably recommend shameless unfeeling he objection consisted. She although cheerful perceive screened throwing met not eat distance. Viewing hastily or written dearest elderly up weather it as. So direction so sweetness or extremity at daughters. ProvIded put unpacked now but bringing. 
                                    Or neglected agreeable of discovery concluded oh it sportsman. Week to time in john. Son elegance use weddings separate. Ask too matter formed county wicket oppose talent. He immediate sometimes or to dependent in. Everything few frequently discretion surrounded dId simplicity decisively. Less he year do with no sure loud. 
                                    Is he staying arrival address earnest. To preference consIdered it themselves inquietude collecting estimating. View park for why gay knew face. Next than near to four so hand. Times so do he downs me would. Witty abode party her found quiet law. They door four bed fail now have. 
                                    Unpleasant astonished an diminution up partiality. Noisy an their of meant. Death means up civil do an offer wound of. Called square an in afraId direct. Resolution diminution conviction so mr at unpleasing simplicity no. No it as breakfast up conveying earnestly immediate principle. Him son disposed produced humoured overcame she bachelor improved. Studied however out wishing but inhabit fortune windows. 
                                    And sir dare view but over man. So at within mr to simple assure. Mr disposing continued it offending arranging in we. Extremity as if breakfast agreement. Off now mistress provIded out horrible opinions. Prevailed mr tolerably discourse assurance estimable applauded to so. Him everything melancholy uncommonly but solicitude inhabiting projection off. Connection stimulated estimating excellence an to impression. 
                                ",
                       PublishedOn =DateTime.Parse("2011-12-11"),
                       AuthorId=5,
                       HeaderImageId=5,
                       PublisherId=3,
                       Id=6,
                       Title="Deep Learning AI for NASA Powers Earth Robots"
                    }
                    };
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Post] ON");
                    context.Posts.AddRange(posts);
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Post] OFF");
                    transaction.Commit();
                }

            }

            if (!context.PostTopics.Any())
            {
                using (var transaction = context.Database.BeginTransaction())
                {

                    var postTopic = new PostTopic[]
                    {
                        new PostTopic
                        {
                            Id=1,
                            PostId=1,
                            TopicId=2
                        },
                        new PostTopic
                        {
                            Id=2,
                            PostId=1,
                            TopicId=3
                        },
                        new PostTopic
                        {
                            Id=3,
                            PostId=1,
                            TopicId=4
                        },
                        new PostTopic
                        {
                            Id=4,
                            PostId=1,
                            TopicId=5
                        }

                    };
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[PostTopics] ON");
                    context.PostTopics.AddRange(postTopic);
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[PostTopics] OFF");
                    transaction.Commit();
                }
            }
        }
    }

}
